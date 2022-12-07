from utils import read_file 
import queue

in_file = read_file('day5.txt')
n_queues = 0
start_row = 0
stacks = []
for file_index, line in enumerate(in_file):
    if n_queues == 0:
        n_queues = len(line) // 4
        stacks = [[] for _ in range(n_queues)]
    
    if line == '\n' or line[1] == '1':
        start_row = file_index
        break

    for queue_num, index in enumerate(range(0, len(line), 4)):
        val = line[index + 1]
        if val.strip():
            stacks[queue_num].append(val)


for idx in range(len(stacks)):
    stacks[idx].reverse()


part_2_stacks = [stack.copy() for stack in stacks]
    
for step in in_file[start_row+2:]:
    _move, n, _from, from_queue, _to, to_queue = step.strip().split(" ")
    print(n, from_queue, to_queue)

    for _ in range(int(n)):
        popped = stacks[int(from_queue) - 1].pop()
        print(popped)
        stacks[int(to_queue) - 1].append(popped)
    
print("".join([stacks[i].pop() for i in range(n_queues)]))


for step in in_file[start_row+2:]:
    _move, n, _from, from_queue, _to, to_queue = step.strip().split(" ")
    print(n, from_queue, to_queue, part_2_stacks)

    n_to_move = int(n)
    from_queue_idx = int(from_queue) - 1
    to_queue_idx = int(to_queue) - 1
    popped = part_2_stacks[from_queue_idx][-1 * n_to_move:]
    print(n_to_move, popped)
    part_2_stacks[from_queue_idx] = part_2_stacks[from_queue_idx][:-1 * n_to_move]
    part_2_stacks[to_queue_idx].extend(popped)

print("".join([part_2_stacks[i].pop() for i in range(n_queues)]))
    