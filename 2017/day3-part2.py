
puzzleInput = 289326

grid = [[0]*(puzzleInput/10) for i in range(puzzleInput/10)]

def solvePuzzle():
    xOffset = puzzleInput/20
    yOffset = puzzleInput/20
    print 'start'
    x = xOffset
    y = yOffset
    spacesAdvanced = 1
    grid[xOffset][yOffset] = 1
    x+=1
    spacesAdvanced = 1
    count = 1
    sidelength = 2
    for i in range(puzzleInput):
        count+= 1
        if i%100 ==0: print i
        grid[x][y] = sumSurrounding(x, y)
        if grid[x][y] > puzzleInput:
            print grid[x][y]
            break
        (x,y,spacesAdvanced,sidelength) = advance(spacesAdvanced, x, y,sidelength)
    return True

def printGrid(grid):
    for i in range(len(grid)):
        output = ""
        for j in range(len(grid)):
            output += str(grid[i][j]) + " "
        print output
    print "--"

def advance(spacesAdvanced, x, y,sidelength):
    if spacesAdvanced < sidelength:
        y += 1
        spacesAdvanced += 1
        return x,y,spacesAdvanced, sidelength

    if spacesAdvanced < sidelength*2:
        x -= 1
        spacesAdvanced += 1

        return x,y,spacesAdvanced, sidelength

    if spacesAdvanced < sidelength*3:
        y -= 1
        spacesAdvanced += 1
        return x,y,spacesAdvanced, sidelength

    spacesAdvanced += 1
    x += 1
    if spacesAdvanced == sidelength*4 + 1:
        sidelength += 2
        spacesAdvanced = 1
    return x,y,spacesAdvanced, sidelength

def sumSurrounding(x,y):
    return grid[x-1][y-1] + grid[x-1][y] + grid[x-1][y+1] + grid[x][y-1] + grid[x][y+1] + grid[x+1][y-1]+grid[x+1][y]+grid[x+1][y+1]

print solvePuzzle()
