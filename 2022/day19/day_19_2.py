import re
from dataclasses import dataclass, replace

@dataclass
class RobotCost:
    ore: int = 0
    clay: int = 0
    obsidian: int = 0
    geode: int = 0

@dataclass
class State:
    steps_remaining: int

    ore: int = 0
    clay: int = 0
    obsidian: int = 0
    geode: int = 0

    ore_robots: int = 0
    clay_robots: int = 0
    obsidian_robots: int = 0
    geode_robots: int = 0

    def hash(self):
        return f"{self.ore}-{self.clay}-{self.obsidian}-{self.geode}-{self.ore_robots}-{self.clay_robots}-{self.obsidian_robots}-{self.geode_robots}-{self.steps_remaining}"

    def possible_score(self):
        return self.geode_robots * self.steps_remaining + self.geode + (self.steps_remaining * (self.steps_remaining-1) / 2)

def get_new_robot_options(state, robot_costs):
    ones_we_can_create = []
    for robot, cost in robot_costs.items():
        can_create = True
        if state.ore >= cost.ore and state.clay >= cost.clay and state.obsidian >= cost.obsidian and state.geode >= cost.geode:
            ones_we_can_create.append(robot)
    return ones_we_can_create
    
def get_state_after_robot_purchase(robot_type, state, robot_costs):
    new_state = replace(state)
    new_state.ore -= robot_costs[robot_type].ore
    new_state.clay -= robot_costs[robot_type].clay
    new_state.obsidian -= robot_costs[robot_type].obsidian
    new_state.geode -= robot_costs[robot_type].geode

    robot_key = robot_type + "_robots"
    setattr(new_state, robot_key, getattr(new_state, robot_key)+1)

    return new_state


def get_new_states(state, robot_costs):
    robots_to_create = get_new_robot_options(state, robot_costs)
    state_copy = replace(state)

    if any(getattr(state_copy, robot + "_robots") > 20 for robot in robot_costs.keys()): 
        return []

    state_copy.ore += state_copy.ore_robots
    state_copy.clay += state_copy.clay_robots
    state_copy.obsidian += state_copy.obsidian_robots
    state_copy.geode += state_copy.geode_robots
    state_copy.steps_remaining -= 1


    new_states = [state_copy]
    new_states.extend(get_state_after_robot_purchase(robot, state_copy, robot_costs) for robot in robots_to_create)
    return new_states


def get_score(input_str, start_state):
    blueprint_num = int(re.findall(r"Blueprint (\d+):.*", input_str)[0])

    re_str = r"Each (\w+) robot costs ([\d,\w,\s]*)\."
    types_and_costs = re.findall(re_str, input_str)
    cost_re_str = r"(\d+) (\w+)"
    robot_costs = {}
    for robot_type, cost in types_and_costs:
        costs = re.findall(cost_re_str, cost)
        robot_costs[robot_type] = RobotCost(**{c[1]: int(c[0]) for c in costs})
    print(robot_costs)


    visited = set()
    states = [start_state]
    count = 0
    max_result = 0
    while states:
        count += 1
        state = states.pop()
        
        if state.hash() not in visited:
            visited.add(state.hash())

            if state.steps_remaining == 0:
                if state.geode > max_result:
                    print(count, state.geode)
                max_result = max(max_result, state.geode)
                continue

            if state.possible_score() < max_result:
                continue

            states = states + get_new_states(state, robot_costs) 

    print(blueprint_num, max_result)
    return max_result, int(blueprint_num) * max_result


# with open("day_19.txt") as f:
#     results = [get_score(in_str, State(steps_remaining=24, ore_robots=1)) for in_str in f.readlines()]

# print(results, sum(_[1] for _ in results))


with open("day_19.txt") as f:
    results = [get_score(in_str, State(steps_remaining=32, ore_robots=1)) for in_str in f.readlines()[:3]]

print(results, sum(_[0] for _ in results))
