from fileImport import *

data = readLines("day7.txt")

base = []
leaf = []

for i in range(len(data)):
    line = data[i]
    base.append(line[0:line.find(' ')])

for i in range(len(data)):
    line = data[i]
    if line.find('>') == -1: continue
    substring = line[line.find('>')+ 1:]
    lines = [x.strip() for x in substring.split(',')]
    for j in range(len(lines)):
        base.remove(lines[j])

print base


