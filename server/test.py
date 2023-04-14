import base64
import struct
import json
def bytes_to_int(bytes):
    result = 0
    for b in bytes:
        result = result * 256 + int(b)
    return result

def int_to_bytes(value, length):
    result = []
    for i in range(0, length):
        result.append(value >> (i * 8) & 0xff)
    return result


testnum = 1000000000
testnum2 = 20
testdata = "signal"
datalen = len(testdata)
print("ddd   ", datalen)

septer = 392

a = septer.to_bytes(4,'little')
print(a)
signal = "alert"
c = bytearray(signal, "utf-8")



b = int_to_bytes(septer,4)
print(b)

#
# test = json.dumps(testdata)
# print(test)
# test1 = test.encode()
# print(test1)
