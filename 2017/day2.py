from fileImport import *

data = readLines("day2.txt")

checksum = 0
for i in range(len(data)):
    array = map(int, data[i].split())
    maxVal = max(array)
    minVal = min(array)
    checksum += (maxVal - minVal)

print checksum


checksum = 0
for i in range(len(data)):
    array = map(int, data[i].split())
    for j in range(len(array)):
        for k in range(len(array)):
            if j == k: continue
            if array[j] % array[k] == 0:
                checksum += array[j]/array[k]

print checksum