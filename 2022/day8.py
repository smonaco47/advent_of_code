from utils import read_file 


in_file = read_file('day8.txt')

ROWS = [row.strip() for row in in_file]

height = len(ROWS)
width = len(ROWS[0])

print("height:", height)
print("width:", width)

def is_visible(x: int, y:int) -> bool:
    val = ROWS[x][y]
    above, a_visible = is_visible_above(x,y, val)
    below, b_visible = is_visible_below(x,y, val)
    left, l_visible = is_visible_left(x,y, val)
    right, r_visible = is_visible_right(x,y, val)
    # print(above, left, right, below)
    return above*left*right*below, a_visible or b_visible or l_visible or r_visible 

def is_visible_above(x, y, val):
    if x == 0:
        return 0, True
    if val <= ROWS[x-1][y]:
        return 1, False
    else:
        score, visible = is_visible_above(x-1, y, val)
        return score + 1, visible

def is_visible_below(x, y, val):
    if x == height-1:
        return 0, True
    if val <= ROWS[x+1][y]:
        return 1, False
    else:
        score, visible = is_visible_below(x+1, y, val)
        return score + 1, visible

def is_visible_left(x, y, val):
    if y == 0:
        return 0, True
    if val <= ROWS[x][y-1]:
        return 1, False
    else:
        score, visible = is_visible_left(x, y-1, val)
        return score + 1, visible

def is_visible_right(x,y, val):
    if y == width-1:
        return 0, True
    if val <= ROWS[x][y+1]:
        return 1, False
    else:
        score, visible = is_visible_right(x, y+1, val)
        return score + 1, visible

total_visible = 0
scenic_scores = set()
for i in range(height):
    scores = []
    for j in range(width):
        score, visible = is_visible(i,j)
        scenic_scores.add(score)
        # print(i,j, score)
        if visible:
            total_visible += 1


# print(is_visible(1,2))
# print(is_visible(3,2))

print("Part 1", total_visible)
print("Part 2",max(scenic_scores))