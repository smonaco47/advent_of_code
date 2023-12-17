use crate::solutions::utils;
use std::collections::{HashMap, HashSet};

pub fn day_3(part_num: &str, file_path: &str) {
    let input = utils::read_to_2d_array(file_path);
    let mut result = 0;
    match part_num {
        "1" => result = run_day_3_part_1(input),
        "2" => result = run_day_3_part_2(input),
        _ => println!("Unknown part number"),
    }
    println!("{result}");
}

pub fn run_day_3_part_1(input: Vec<Vec<char>>) -> u32 {
    let mut total_digits: u32 = 0;
    for (row_index, row) in input.iter().enumerate() {
        let mut current_digit: u32 = 0;
        let mut is_touching_special = false;
        for (col_index, column) in row.iter().enumerate() {
            if column.is_digit(10) {
                is_touching_special = is_touching_special
                    || !_touches_character(&input, row_index, col_index).is_empty();
                current_digit = current_digit * 10 + column.to_digit(10).unwrap()
            } else {
                if is_touching_special {
                    total_digits += current_digit;
                }
                current_digit = 0;
                is_touching_special = false;
            }
        }
        if is_touching_special {
            total_digits += current_digit;
        }
    }
    return total_digits;
}

pub fn run_day_3_part_2(input: Vec<Vec<char>>) -> u32 {
    let mut touching_stars = HashMap::new();
    let mut running_total = 0;
    for (row_index, row) in input.iter().enumerate() {
        let mut current_digit: u32 = 0;
        let mut stars: HashSet<(u32, u32)> = HashSet::new();
        for (col_index, column) in row.iter().enumerate() {
            if column.is_digit(10) {
                let new_special_chars = _touches_character(&input, row_index, col_index);
                let stars_for_char: Vec<_> = new_special_chars
                    .into_iter()
                    .filter(|(c, _, _)| c == &'*')
                    .map(|(_, r, co)| (r, co))
                    .collect();
                stars.extend(stars_for_char);
                current_digit = current_digit * 10 + column.to_digit(10).unwrap()
            } else {
                for star in stars.clone() {
                    let existing_star = touching_stars.get(&star);
                    if existing_star.is_some() {
                        running_total += current_digit * existing_star.unwrap()
                    } else {
                        touching_stars.insert(star, current_digit);
                    }
                }
                stars.clear();
                current_digit = 0;
            }
        }
    }

    return running_total;
}

fn _touches_character(
    input: &Vec<Vec<char>>,
    row_index: usize,
    col_index: usize,
) -> Vec<(char, u32, u32)> {
    let mut characters: Vec<(char, u32, u32)> = vec![];
    for wrapped_row in [
        row_index.checked_sub(1),
        Some(row_index),
        Some(row_index + 1),
    ] {
        if !wrapped_row.is_some() {
            continue;
        }
        let row = wrapped_row.unwrap();
        for wrapped_col in [
            col_index.checked_sub(1),
            Some(col_index),
            Some(col_index + 1),
        ] {
            if !wrapped_col.is_some() {
                continue;
            }
            let col = wrapped_col.unwrap();
            if row_index == row && col_index == col {
                continue;
            }
            if input.get(row).is_some() && input[row].get(col).is_some() {
                if input[row][col] != '.' && !input[row][col].is_digit(10) {
                    characters.push((
                        input[row][col],
                        row.try_into().unwrap(),
                        col.try_into().unwrap(),
                    ))
                }
            }
        }
    }
    return characters;
}

#[cfg(test)]
mod tests {
    #[test]
    fn test_part_1_simple() {
        let test_input = vec![
            vec!['4', '6', '7', '.', '.', '1', '1', '4', '.', '.'],
            vec!['.', '.', '.', '*', '.', '.', '.', '.', '.', '.'],
        ];
        let result = crate::solutions::day_3::run_day_3_part_1(test_input);
        assert_eq!(result, 467);
    }

    #[test]
    fn test_part_2() {
        let test_input = vec![
            vec!['4', '6', '7', '.', '.', '1', '1', '4', '.', '.'],
            vec!['.', '.', '.', '*', '.', '.', '.', '.', '.', '.'],
            vec!['.', '.', '3', '5', '.', '.', '6', '3', '3', '.'],
        ];
        let result = crate::solutions::day_3::run_day_3_part_2(test_input);
        assert_eq!(result, 16345);
    }
}
