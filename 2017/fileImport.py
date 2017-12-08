def importFile(filename):
    return open(filename).read()

def readLines(filename):
    return str.splitlines(importFile(filename))

def readToTwoDimensionalIntArray(filename):
    data = readLines(filename)
    output = []
    for i in range(len(data)):
        output.append(map(int, data[i].split()))
    return output