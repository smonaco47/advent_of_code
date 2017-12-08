

initialState = [14 ,0 ,15, 12 ,11,	11,	3,	5,	1,	6,	8,	4,	9,	1,	8,	4]
state = [14 ,0 ,15, 12 ,11,	11,	3,	5,	1,	6,	8,	4,	9,	1,	8,	4]

initialState = [0, 2, 7, 0]
state = [0, 2, 7, 0]

numBanks = len(initialState)
visitedStates = []
stateIndex = 0


def distribute(state) :
    indexOfMax = state.index(max(state))
    numberForEach = state[indexOfMax]/numBanks
    extras = state[indexOfMax]%numBanks
    state[indexOfMax] = 0
    for i in range(numBanks):
        index = (indexOfMax + i + 1)%numBanks
        state[index] += numberForEach
        if (extras > 0):
            state[index] += 1
            extras -=1
    return state

def isMatch(state1, state2):
    for i in range(numBanks):
        if state1[i] != state2[i]:
            return False
    return True

def hasMatch(state):
    for i in range(len(visitedStates)):
        if isMatch(visitedStates[i], state):
            print i
            return True
    visitedStates.append(state[:])
    return False

count = 1
visitedStates.append(initialState)
distribute(state)
while hasMatch(state) != True:
    distribute(state)
    count +=1

print count - stateIndex
print count
print state