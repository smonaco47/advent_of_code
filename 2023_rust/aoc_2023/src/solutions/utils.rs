use std::fs;

pub fn read_to_string(file_name: &str) -> String{
    let contents = fs::read_to_string(file_name)
        .expect("Should have been able to read the file");
    return contents;
}

pub fn read_to_vec_of_strings(file_name: &str) -> Vec<String>{
    let input = read_to_string(file_name);
    return Vec::from_iter(input.split('\n').map(str::to_string));
}

pub fn read_to_2d_array(file_name: &str) -> Vec<Vec<char>>{
    let input_str: String = read_to_string(file_name);
    let mut v: Vec<Vec<char>> = vec![];
    let mut row_v: Vec<char> = vec![];
    for c in input_str.chars(){
        if c == '\n' && !row_v.is_empty(){
            v.push(row_v.clone());
            row_v.clear();
        }
        else {
            row_v.push(c);
        }
    }
    if !row_v.is_empty(){
        v.push(row_v.clone());
    }
    return v;
}