from fileImport import *
import datetime

def init(input):
    ranges = {}
    currentScan = {}
    direction = {}
    for line in input:
        key = int(line[:line.find(':')])
        ranges[key] = int(line[line.find(':')+1:])
        direction[key] = 1
        currentScan[key] = 0
    return ranges,direction,currentScan

def advanceScanners(ranges, currentScan, direction):
    for key in ranges.keys():
        currentScan[key] += direction[key]
        if currentScan[key] == ranges[key]-1 or currentScan[key]==0:
            direction[key] *= -1

def run(ranges, currentScan, direction,  breakOnHit):
    sum = 0
    delay = 0
    maxIndex = max(ranges.keys())
    currentIndex = 0
    for index in range(maxIndex+1):
        if currentIndex in ranges.keys():
            if currentScan[currentIndex] == 0:
                sum += currentIndex * ranges[currentIndex]
                if breakOnHit:
                    sum = 1
                    break
        currentIndex+=1
        advanceScanners(ranges, currentScan, direction)
    return sum

print datetime.datetime.now()
input = readLines('day13.txt')
sum = 1
iterations = 0
(ranges,direction,currentScan)=init(input)
while sum != 0:
    iterations +=1
    advanceScanners(ranges, currentScan, direction)
    startScan = dict(currentScan)
    startDirection = dict(direction)
    sum = run(ranges, startScan, startDirection, True)
print iterations
print datetime.datetime.now()
