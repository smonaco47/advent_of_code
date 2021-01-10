import numpy as np

data = np.genfromtxt('day2.txt', dtype=np.unicode, delimiter='\n')

twocount = 0
threecount = 0
hastwo = False
hasthree = False
for item in np.nditer(data):
    hastwo = False
    hasthree = False
    for i in range(65, 91):
        char = str(unichr(i + 32))
        count = str(item).count(char)
        if count == 2:
            hastwo = True
        if count == 3:
            hasthree = True
        if hastwo and hasthree:
            break
    two = 1 if hastwo else 0
    three = 1 if hasthree else 0
    twocount += two
    threecount += three

print 'Part 1', twocount * threecount


for item1 in np.nditer(data):
    for item2 in np.nditer(data):
        if item1 == item2:
            continue
        differences = 0
        item1str = str(item1)
        item2str = str(item2)
        for i in range(len(item1str)):
            if item1str[i] != item2str[i]:
                differences += 1
                if differences > 1:
                    continue
        if differences == 1:
            print 'Part 2', item1str, item2str
