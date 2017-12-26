import sys

class Node:
    Left = None
    Right = None
    Value = 0
    
def moveRight(node):
    if node.Right == None:
        newNode = Node()
        node.Right = newNode
        newNode.Left = node
    return node.Right

def moveLeft(node):
    if node.Left == None:
        newNode = Node()
        node.Left = newNode
        newNode.Right = node
    return node.Left

def printNodeCount(node):
    while (node.Left != None):
        node = node.Left
    count = 0
    while node != None:
        count += node.Value
        node = node.Right
    return count

def executeA(node):
    if node.Value == 0:
        node.Value = 1
        node = moveRight(node)
        return node, executeB
    else:
        node.Value = 0
        node = moveLeft(node)
        return node, executeB
    
def executeB(node):
    if node.Value == 0:
        node.Value = 0
        node = moveRight(node)
        return node, executeC
    else:
        node.Value = 1
        node = moveLeft(node)
        return node, executeB

def executeC(node):
    if node.Value == 0:
        node.Value = 1
        node = moveRight(node)
        return node, executeD
    else:
        node.Value = 0
        node = moveLeft(node)
        return node, executeA

def executeD(node):
    if node.Value == 0:
        node.Value = 1
        node = moveLeft(node)
        return node, executeE
    else:
        node.Value = 1
        node = moveLeft(node)
        return node, executeF
    
def executeE(node):
    if node.Value == 0:
        node.Value = 1
        node = moveLeft(node)
        return node, executeA
    else:
        node.Value = 0
        node = moveLeft(node)
        return node, executeD

def executeF(node):
    if node.Value == 0:
        node.Value = 1
        node = moveRight(node)
        return node, executeA
    else:
        node.Value = 1
        node = moveLeft(node)
        return node, executeE

node = Node()
node,next = executeA(node)
for i in range(12629077-1):
    node,next = next(node)
    if i %10000 ==0:
        print i
        sys.stdout.flush()
print printNodeCount(node)