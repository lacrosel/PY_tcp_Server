import socketserver
import json
import threading
import time
import random
import copy
from datetime import datetime
import os
os.environ["OPENCV_VIDEOIO_MSMF_ENABLE_HW_TRANSFORMS"] = "0"
sized = 32
import time
import cv2
import mediapipe as mp
import tensorflow as tf
import numpy as np
import matplotlib.pyplot as plt
from tensorflow.keras.preprocessing.image import ImageDataGenerator
import pymysql


class functions():
    def __init__(self, server):
        self.serv = server
        self.dbsignal = True


    def DBConnect(self):
        conn = pymysql.connect(host="10.10.21.107", user="user", port=3306, password="12345678",
                                    database="opencv")
        cursor = conn.cursor()
        now = datetime.now()
        dates = now.strftime('%Y-%m-%d-%H:%M:%S')
        cursor.execute(f"INSERT INTO opencv.sleep(times) values ('{dates}')")
        conn.commit()
        conn.close()

    def bytes_to_int(self, bytes):
        result = 0
        for b in bytes:
            result = result * 256 + int(b)
        return result

    def int_to_bytes(self, value, length):
        result = []
        for i in range(0, length):
            result.append(value >> (i * 8) & 0xff)
        result.reverse()
        return result

    def ImagePredict(self, detect, draw, model, datalist, image):
        # self.func.ImagePredict(mp_face_detection, mp_drawing, model, testlist, image)
        with detect.FaceDetection(model_selection=0,
                                  min_detection_confidence=0.5) as face_detection:
            image = cv2.cvtColor(cv2.flip(image, 1), cv2.COLOR_BGR2RGB)

            # 성능을 향상시키려면 이미지를 작성 여부를 False으로 설정하세요.
            image.flags.writeable = False
            imageview = cv2.cvtColor(image, cv2.COLOR_RGB2BGR)
            # cv2.imshow("img orgin", imageview)
            results = face_detection.process(image)
            # 영상에 얼굴 감지 주석 그리기 기본값 : True.

            if results.detections:
                for detection in results.detections:
                    bboxC = detection.location_data.relative_bounding_box
                    ih, iw, _ = image.shape
                    x, y, w, h = int(bboxC.xmin * iw), int(bboxC.ymin * ih), int(bboxC.width * iw), int(
                        bboxC.height * ih)
                    cv2.rectangle(image, (x, y), (x + w, y + h), (255, 0, 0), 1)  # boundbox 그리기

                    left_eye_x = int((detection.location_data.relative_keypoints[0].x) * w) + x
                    left_eye_y = int((detection.location_data.relative_keypoints[0].y) * h) + y
                    right_eye_x = int((detection.location_data.relative_keypoints[1].x) * w) + x
                    right_eye_y = int((detection.location_data.relative_keypoints[1].y) * h) + y

                # 이미지 컷
                if (right_eye_y >= left_eye_y):
                    cropped_facet = image[y + int(abs(right_eye_y - left_eye_y) * 0.5):right_eye_y,
                                    x - int(abs(right_eye_y - left_eye_y) * 0.5):x + int(w * 0.5)]
                else:
                    cropped_facet = image[y + int(abs(left_eye_y - right_eye_y) * 0.5):left_eye_y,
                                    x + int(w * 0.5):x + w]
                if cropped_facet.size > 0:  # cropped_face가 비어있지 않은 경우에만 이미지 표시
                    cropped_face = cv2.cvtColor(cropped_facet, cv2.COLOR_RGB2GRAY)
                    height, width = cropped_facet.shape[:2]

                    # 이미지의 크기가 유효한지 확인
                    if width > 0 and height > 0:
                        # 이미지 표시
                        # cv2.imshow("Cropped face", cropped_face)
                        cropped_face2 = cv2.resize(cropped_face, (32, 32))

                        cropped_face3 = np.array(cropped_face2)
                        predictions = model.predict(np.expand_dims(cropped_face3, axis=0))
                        # # 예측 결과를 출력합니다.
                        class_names = ['close eyes', 'open eyes']
                        predicted_class = np.argmax(predictions)
                        # print('Predicted class:', class_names[predicted_class])
                        if (predicted_class == 0):
                            datalist.append(predicted_class)
                        else:
                            datalist.append(predicted_class)
                            datalist.append(predicted_class)
                        if (len(datalist) > 30):
                            for i in range(len(datalist) - 30):
                                datalist.pop(0)

                        if (len(datalist) == 30):
                            closenum = datalist.count(0)
                            percent = closenum / len(datalist) * 100
                            if (percent > 80):
                                print(" close eye  - ", percent, "%")
                                septer = 1
                                a = septer.to_bytes(4, 'little')
                                signal = "alert"
                                datalen = len(signal)
                                b = datalen.to_bytes(4, 'little')
                                c = bytearray(signal, "utf-8")

                                self.serv.request.send(a + b + c)
                                if (self.dbsignal):
                                    self.DBConnect()
                                    self.dbsignal = False
                            else:
                                print(" open eye  - ", percent, "%")


lock = threading.Lock()  # lock 선언


class TCPhandler(socketserver.BaseRequestHandler):

    def setup(self):
        print("연결 완료")
        self.Running = True
        self.func = functions(self)
        self.mp_face_detection = mp.solutions.face_detection
        self.mp_drawing = mp.solutions.drawing_utils
        self.model = tf.keras.models.load_model('C:/Users/kiot/model_128_3_15_32_1.h5')
        self.testlist = []

    def handle(self):  # 클라에서 신호 보낼시 자동으로 동작
        try:
            while (self.Running):
                startidx = 0
                recvdata = self.request.recv(512)  # 접속된 사용자로부터 입력대기
                if len(recvdata) <= -1:
                    print("connect error!!")
                    break
                elif len(recvdata) == 0:
                    continue
                # 헤더검출
                septer1 = int.from_bytes(recvdata[startidx:startidx + 4], "little")
                startidx += 4
                septer2 = int.from_bytes(recvdata[startidx:startidx + 4], "little")
                startidx += 4

                if septer1 == 1:
                    datalen = int.from_bytes(recvdata[startidx:startidx + 4], "little")
                    startidx += 4

                    totaldata = recvdata[startidx:startidx + datalen]

                    while (len(totaldata) < datalen):
                        recved = self.request.recv(datalen - len(totaldata))
                        totaldata += recved

                    if len(totaldata) > 0:
                        nparr = np.frombuffer(totaldata, np.uint8)

                        # numpy 배열을 이미지로 디코딩
                        image = cv2.imdecode(nparr, cv2.IMREAD_GRAYSCALE)
                        self.func.ImagePredict(self.mp_face_detection, self.mp_drawing, self.model, self.testlist,
                                               image)

                elif septer1 == 2:
                    self.func.dbsignal = True
                    print("==========================dbdbdbdbdbdb===========================")

        except Exception as e:  # 어떤 에러 일지 모르니까 표시만 하고 서버 멈추지는 않도록 처리.
            print("==========================================================================================")
            print(e)

        print('▷ [%s] disConnection' % self.client_address[0])


# socketserver.ThreadingMixIn: 독립된 스레드로 처리하도록 접속시 마다 새로운 스레드 생성
# 직접적으로 스레드 동작하게 지정해주는거랑 같다. 대신 이미 누가 메서드로 만들어 놓은거 사용하는 것.
# ThreadingMixIn(소켓서버 스레드 동작), TCPServer class(스레드 동작시킬 위에서 정의한 TCPserver) 상속
class ChatingServer(socketserver.ThreadingMixIn, socketserver.TCPServer):
    pass  # 이건 단순하게 스레드 동작 하게 한다는 거니까 특별히 뭘 적어줄 필요 x


if __name__ == "__main__":
    address = ("10.10.21.106", 9999)

    print('▷ 채팅 서버를 시작합니다.')
    print('▷ 채팅 서버를 끝내려면 Ctrl-C를 누르세요.')

    try:
        server = ChatingServer(address, TCPhandler)
        server.serve_forever()  # 무한 실행
    except KeyboardInterrupt:  # Ctrl + C 입력시 종료
        print('▷ 채팅 서버를 종료합니다.')
        server.shutdown()  # 서버 종료
        server.server_close()  # 메모리 해제
