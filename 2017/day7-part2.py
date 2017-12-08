from fileImport import *

data = readLines("day7.txt")

links = {}
weights = {}

for i in range(len(data)):
    line = data[i]
    base = line[0:line.find(' ')]
    weight = line[line.find('(')+1:line.find(')')]
    weights[base] = weight
    if line.find('>') == -1: continue
    lines = [x.strip() for x in line[line.find('>')+ 1:].split(',')]
    links[base] = lines

def GetChildWeights(root, links, weights):
    if root not in links:
        return int(weights[root])
    values = {}
    children = links[root]
    sum = 0
    for i in range(len(children)):
        childValue = GetChildWeights(children[i], links, weights)
        sum += childValue
        if childValue not in values:
            values[childValue] = {}
        values[childValue][children[i]] = 1
    if len(values) > 1:
        print 'Unbalanced!!' + root
        print values
    return sum + int(weights[root])



GetChildWeights('dtacyn', links, weights)
print base



print weights['ptshtrn']