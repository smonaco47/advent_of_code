from typing import Iterable

def read_file(filename: str) -> Iterable[str]:
    with open(filename) as file:
        return file.readlines()