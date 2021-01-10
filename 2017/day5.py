from fileImport import *
from utility import *

data = readLines("day5.txt")

steps = [int(x) for x in data]

pointer = 0
count = 1
lastPointer = 0
while pointer < len(steps):
    lastPointer = pointer
    pointer += steps[pointer]
    if pointer >= len(steps): break
    steps[lastPointer]+=1
    count+=1



print 'Part 1: ',count


steps = [int(x) for x in data]

pointer = 0
count = 1
lastPointer = 0
while pointer < len(steps):
    lastPointer = pointer
    pointer += steps[pointer]
    if pointer >= len(steps): break

    if steps[lastPointer] >= 3: steps[lastPointer]-=1
    else: steps[lastPointer]+=1
    count+=1



print 'Part 2: ',count