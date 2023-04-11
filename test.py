import base64
import struct

def bytes_to_int(bytes):
    result = 0
    for b in bytes:
        result = result * 256 + int(b)
    return result

def int_to_bytes(value, length):
    result = []
    for i in range(0, length):
        result.append(value >> (i * 8) & 0xff)
    result.reverse()
    return result


testnum = 1000000000
testnum2 = 20
testdata = "가나다라마바사아자차카타파하"

tb1 = int_to_bytes(testnum, 4) #4바이트로 표현함.
print(tb1)

tb2 = tb1.reverse()
print(tb1)


