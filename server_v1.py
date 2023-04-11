import socketserver
import json
import threading
import time
import random
import copy
from datetime import datetime

# import pygame
import pymysql

class functions():
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

lock = threading.Lock()  # lock 선언

class TCPhandler(socketserver.BaseRequestHandler):
    func = functions()

    def setup(self):
        print("1")
        self.Running = True

    def handle(self):  # 클라에서 신호 보낼시 자동으로 동작
        try:
            while (self.Running):
                msg = self.request.recv(512)  # 접속된 사용자로부터 입력대기
                temp = msg[:4]
                print(temp)
                test = self.func.bytes_to_int(msg[:4])
                test.
                print(test)

                # while msg:
                #     # print(msg.decode())  # 서버 화면에 출력
                #     Cmsg = msg.decode().split('!*!:!*!')
                #     print('Cmsg', Cmsg)
                #
                #     msg = self.request.recv(1024)  # 메시지 수신 대기

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
    address = ("10.10.21.106", 9797)

    print('▷ 채팅 서버를 시작합니다.')
    print('▷ 채팅 서버를 끝내려면 Ctrl-C를 누르세요.')

    try:
        server = ChatingServer(address, TCPhandler)
        server.serve_forever()  # 무한 실행
    except KeyboardInterrupt:  # Ctrl + C 입력시 종료
        print('▷ 채팅 서버를 종료합니다.')
        server.shutdown()  # 서버 종료
        server.server_close()  # 메모리 해제