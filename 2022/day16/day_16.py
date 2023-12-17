import re
from dataclasses import dataclass, replace, field


@dataclass
class State:
    steps_remaining: int
    current_location: str
    total_flow_rate: int
    open_valves: set[str] = field(default_factory=lambda: set())
    closed_valves: set[str] = field(default_factory=lambda: set())
    flow_rate: int = 0
    released_pressure: int = 0

    def possible_score(self):
        return self.flow_rate * self.steps_remaining + self.released_pressure + (self.total_flow_rate - self.flow_rate) * (self.steps_remaining - len(self.closed_valves) + 1)

    def target(self):
        return self.released_pressure

    def hash(self):
        return f"{self.steps_remaining}|{self.current_location}|{self.flow_rate}|{self.released_pressure}|{".".join(self.open_valves)}|{".".join(self.closed_valves)}"


def get_new_states(state, tunnel_input):
    state_copy = replace(state)
    state_copy.steps_remaining -= 1
    state_copy.released_pressure += state.flow_rate

    new_states = [state_copy]

    if state.current_location in state.closed_valves and tunnel_input[state.current_location]["flow_rate"] > 0:
        open_state = replace(state_copy)
        open_state.open_valves = state_copy.open_valves.copy()
        open_state.open_valves.add(state.current_location)

        open_state.closed_valves = state_copy.closed_valves.copy()
        open_state.closed_valves.remove(state.current_location)

        open_state.flow_rate += tunnel_input[state.current_location]["flow_rate"]
        new_states.append(open_state)

    for possible_destination in tunnel_input[state.current_location]["to_valves"]:
        new_state = replace(state_copy)
        new_state.current_location = possible_destination
        new_states.append(new_state)

    return new_states


def build_input(input_strs: list[str]):
    tunnel_dict = {}
    for input_str in input_strs:
        valve_name, flow_rate = re.findall(r"Valve (\w+) has flow rate=(\d+);.*", input_str)[0]

        to_valves_str = re.findall(r"tunnel[s]* lead[s]* to valve[s]* ([\d,\w,\s]*)", input_str)
        print(to_valves_str)
        if to_valves_str:
            to_valves = set(_.strip() for _ in to_valves_str[0].split(","))
        else:
            to_valves = set()

        tunnel_dict[valve_name] = {
            "flow_rate": int(flow_rate),
            "to_valves": to_valves
        }

    # Sanity check
    tunnel_keys = set(tunnel_dict.keys())
    tunnel_to_valve = set()
    for key in tunnel_dict:
        tunnel_to_valve.update(tunnel_dict[key]["to_valves"])
    assert tunnel_to_valve == tunnel_keys
    
    return tunnel_dict


def get_max_flow(state, tunnel_input):
    visited = set()
    states = [state]
    count = 0
    max_result = 0
    while states:
        count += 1
        state = states.pop()
        
        if state.hash() not in visited:
            visited.add(state.hash())

            if state.steps_remaining == 0:
                if state.target() > max_result:
                    print(count, state.target(), state)
                max_result = max(max_result, state.target())
                continue

            # if state.possible_score() < max_result:
                # continue

            # if not state.closed_valves:
            #     max_result = max(max_result, state.flow_rate * state.steps_remaining)
            #     continue

            states = states + get_new_states(state, tunnel_input)

    return max_result



with open("day_16.txt") as f:
    tunnel_input = build_input(list(f.readlines()))
    print(tunnel_input)
    total_flow_rate = sum(tunnel_input[key]["flow_rate"] for key in tunnel_input)
    useful_valves = set(k for k in tunnel_input.keys() if tunnel_input[k]["flow_rate"]>0)
    results = get_max_flow(State(steps_remaining=30, current_location="AA", total_flow_rate=total_flow_rate, closed_valves=useful_valves), tunnel_input)

print(results)

    # for s in [
    #     # State(steps_remaining=30, current_location="AA", total_flow_rate=total_flow_rate, closed_valves={"BB", "DD", "JJ", "CC", "EE", "HH"}),
    #     # State(steps_remaining=28, current_location='DD', total_flow_rate=81, open_valves={'DD'}, closed_valves={'JJ', 'HH', 'CC', 'BB', 'EE'}, flow_rate=20, released_pressure=0)
    #     # State(steps_remaining=27, current_location='CC', total_flow_rate=81, open_valves={'DD'}, closed_valves={'HH', 'CC', 'JJ', 'EE', 'BB'}, flow_rate=20, released_pressure=20)
    #     # State(steps_remaining=26, current_location='BB', total_flow_rate=81, open_valves={'DD'}, closed_valves={'EE', 'CC', 'HH', 'BB', 'JJ'}, flow_rate=20, released_pressure=40)
    #     # State(steps_remaining=25, current_location='BB', total_flow_rate=81, open_valves={'BB', 'DD'}, closed_valves={'JJ', 'EE', 'CC', 'HH'}, flow_rate=33, released_pressure=60)
    #     # State(steps_remaining=24, current_location='AA', total_flow_rate=81, open_valves={'BB', 'DD'}, closed_valves={'CC', 'JJ', 'HH', 'EE'}, flow_rate=33, released_pressure=93)
    #     # State(steps_remaining=23, current_location='II', total_flow_rate=81, open_valves={'BB', 'DD'}, closed_valves={'CC', 'JJ', 'EE', 'HH'}, flow_rate=33, released_pressure=126)
    #     # State(steps_remaining=22, current_location='JJ', total_flow_rate=81, open_valves={'DD', 'BB'}, closed_valves={'JJ', 'CC', 'HH', 'EE'}, flow_rate=33, released_pressure=159)
    # ]:
    #     for r in get_new_states(s,tunnel_input):
    #         print(r)

