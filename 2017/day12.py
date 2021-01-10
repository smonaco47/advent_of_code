from fileImport import *

input = readLines('day12.txt')

def parseInput(input):
    output = {}
    for line in input:
        head = int(line[:line.find(' ')])
        substring = line[line.find('>')+ 1:]
        lines = [int(x.strip()) for x in substring.split(',')]
        output[head] = lines
    return output

def getConnectedCount(data, start, connections):
    if start in connections:
        return 0
    connections.add(start)
    sum = 1
    for endpoint in data[start]:
        sum += getConnectedCount(data, endpoint, connections)
    return sum

parsed = parseInput(input)
data = set()
print "Part 1: ", getConnectedCount(parsed, 0, data)

accumulatedData = set()
count = 0
for key in parsed.keys():
    if key in accumulatedData: continue
    connections = set()
    getConnectedCount(parsed, key, connections)
    accumulatedData = accumulatedData|connections
    print connections
    count += 1
print "Part 2:", count