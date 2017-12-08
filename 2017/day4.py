from fileImport import *
from utility import *

data = readLines("day4.txt")

count = 0
for i in range(len(data)):
    lines = [x.strip() for x in data[i].split(' ')]
    if hasDuplicates(lines): continue
    count += 1

print 'Part1',count


count = 0
for i in range(len(data)):
    lines = [''.join(sorted(x.strip())) for x in data[i].split(' ')]
    if hasDuplicates(lines): continue
    count += 1

print 'Part2',count

