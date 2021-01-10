
def solvePuzzle(puzzleInput):
    if puzzleInput == 1: return 0
    i = 1
    while ((i+2) * (i+2) < puzzleInput):
        i+=2

    sidelength = i + 1
    distance = (sidelength / 2)
    startValue = i*i + 1

    print startValue
    print distance
    print sidelength

    x = distance
    y = (sidelength/2 * -1) + 1

    print x, y

    spacesToGo = puzzleInput - startValue
    print spacesToGo
    if spacesToGo < sidelength:
        y += spacesToGo
        return x,y

    y += (sidelength - 1)
    spacesToGo -= (sidelength - 1)
    print x, y
    print spacesToGo

    if spacesToGo <= sidelength:
        x -= spacesToGo
        return x,y

    x -= sidelength
    spacesToGo -= sidelength
    print x, y
    print spacesToGo

    if spacesToGo <= sidelength:
        y -= spacesToGo
        return x,y

    y -= sidelength
    spacesToGo -= sidelength
    print x, y
    print spacesToGo

    x += spacesToGo
    return x,y



print solvePuzzle(289326)