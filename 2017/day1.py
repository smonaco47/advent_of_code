from fileImport import importFile

data = importFile('day1.txt')
count = 0
for i in range(len(data)):
    if (data[i]==data[(i+1)%len(data)]):
        count += int(data[i])

print "Part 1: " + str(count)


count = 0
strLen = len(data)
for i in range(strLen):
    if (data[i]==data[(i+(strLen/2))%strLen]):
        count += int(data[i])

print "Part 2: " + str(count)
