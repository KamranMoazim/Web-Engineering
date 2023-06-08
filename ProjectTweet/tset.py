# Node class to represent puzzle states
class Node:
    def __init__(self, state, parent=None, cost=0):
        self.state = state  # Current state of the puzzle
        self.parent = parent  # Parent node
        self.cost = cost  # Cost to reach the current state

    def __lt__(self, other):
        return self.cost < other.cost

    def __eq__(self, other):
        return self.state == other.state


# Priority queue implementation
class PriorityQueue:
    def __init__(self):
        self.elements = []

    def is_empty(self):
        return len(self.elements) == 0

    def push(self, item):
        self.elements.append(item)

    def pop(self):
        if self.is_empty():
            raise IndexError("Cannot pop from an empty priority queue")
        min_cost_index = 0
        for i in range(1, len(self.elements)):
        # for i in range(0, len(self.elements)):
            if self.elements[i] < self.elements[min_cost_index]:
                min_cost_index = i
        return self.elements.pop(min_cost_index)

# Function to check if the puzzle is solvable
def is_solvable(puzzle):
    inversions = 0
    puzzle_size = len(puzzle)
    blank_row = 0

    for i in range(puzzle_size):
        for j in range(i + 1, puzzle_size):
            # Ignore the 0 tile
            if puzzle[j] == 0:
                continue

            if puzzle[i] > puzzle[j]:
                inversions += 1

        # Find the row containing the blank tile
        if puzzle[i] == 0:
            blank_row = puzzle_size - (i // puzzle_size)

    # Check the solvability conditions
    if puzzle_size % 2 == 1 and inversions % 2 == 0:
        return True
    elif puzzle_size % 2 == 0 and blank_row % 2 == inversions % 2:
        return True

    return False

# Function to calculate the Manhattan distance heuristic
def calculate_manhattan_distance(current_state, goal_state):
    size = int(len(current_state) ** 0.5)
    current_positions = {(current_state[i], i) for i in range(size * size)}
    goal_positions = {(goal_state[i], i) for i in range(size * size)}

    distance = 0
    for number, current_pos in current_positions:
        if number != 0:
            goal_pos = dict(goal_positions)[number]
            current_row, current_col = current_pos // size, current_pos % size
            goal_row, goal_col = goal_pos // size, goal_pos % size
            distance += abs(current_row - goal_row) + abs(current_col - goal_col)

    return distance

# Function to perform A* search
def a_star_search(initial_state, goal_state):
    puzzle_size = int(len(initial_state) ** 0.5)
    actions = [(0, 1), (1, 0), (0, -1), (-1, 0)]  # Actions: right, down, left, up
    action_names = ['R', 'D', 'L', 'U']  # Action names

    # Verify if the initial state contains the blank tile (0)
    if 0 not in initial_state:
        return "Invalid initial state. Blank tile (0) not found."

    # Priority queue to store the nodes
    priority_queue = PriorityQueue()
    priority_queue.push(Node(initial_state, None, 0))

    # Set to keep track of visited states
    visited = set()

    while not priority_queue.is_empty():
        current_node = priority_queue.pop()
        current_state = current_node.state

        # Check if the goal state is reached
        if current_state == goal_state:
            # Generate the action sequence by traversing back to the initial state
            action_sequence = []
            while current_node.parent:
                if 0 in current_state:
                    action_sequence.append(action_names[current_state.index(0)])
            current_node = current_node.parent
            current_state = current_node.state


            action_sequence.reverse()  # Reverse the action sequence
            return ' -> '.join(action_sequence)  # Return the actions separated by '->'

        visited.add(tuple(current_state))

        # Generate child nodes by applying valid moves
        blank_index = current_state.index(0)
        blank_row = blank_index // puzzle_size
        blank_col = blank_index % puzzle_size

        for action in actions:
            new_row = blank_row + action[0]
            new_col = blank_col + action[1]

            if 0 <= new_row < puzzle_size and 0 <= new_col < puzzle_size:
                new_state = current_state.copy()
                new_index = new_row * puzzle_size + new_col

                new_state[blank_index], new_state[new_index] = new_state[new_index], new_state[blank_index]

                # Calculate the cost and heuristic value for the child node
                new_cost = current_node.cost + 1
                heuristic_value = calculate_manhattan_distance(new_state, goal_state)
                total_cost = new_cost + heuristic_value

                # Add the child node to the priority queue if not visited
                if tuple(new_state) not in visited:
                    priority_queue.push(Node(new_state, current_node, total_cost))

    return "No solution found."

# Function to read puzzles from file
def read_puzzles_from_file(file_name):
    puzzles = []
    with open(file_name, "r") as file:
        num_puzzles = int(file.readline().strip())

        for _ in range(num_puzzles):
            puzzle_line = file.readline().strip()
            puzzle = list(map(int, puzzle_line.split()))
            puzzles.append(puzzle)
    # print(puzzles)
    return puzzles


# Main part
file_name = "puzzles.txt"  # Our directory or file
puzzles = read_puzzles_from_file(file_name)

for puzzle in puzzles:
    initial_state = puzzle
    goal_state = [i for i in range(1, len(initial_state))] + [0]
  # Goal state is a sorted list

    if is_solvable(initial_state):
        print("Puzzle is solvable.")
        solution = a_star_search(initial_state, goal_state)
        print(f"Initial State: {initial_state}")
        print(f"Goal State: {goal_state}")
        print(f"Solution: {solution}")
        print()
    else:
        print("Puzzle is unsolvable.")
        print()