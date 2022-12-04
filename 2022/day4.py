pairs = [
    "2-4,6-8",
    "2-3,4-5",
    "5-7,7-9",
    "2-8,3-7",
    "6-6,4-6",
    "2-6,4-8",
]

from utils import read_file 
pairs = [_.strip() for _ in read_file('day4.txt')]


def parse_set(set_str: str) -> set:
    start, end = set_str.split("-")
    start = int(start)
    end = int(end)

    return set(range(start, end+1))

count = 0
for pair in pairs:
    set_str1, set_str2 = pair.split(",")
    set1 = parse_set(set_str1)
    set2 = parse_set(set_str2)
    if set1 >= set2 or set2 >= set1:
        count += 1
        print(set1, set2)

print("Part 1:", count)


count = 0
for pair in pairs:
    set_str1, set_str2 = pair.split(",")
    set1 = parse_set(set_str1)
    set2 = parse_set(set_str2)
    if set1.intersection(set2):
        count += 1
        print(set1, set2)

print("Part 1:", count)