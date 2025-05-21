import math

n = int(input("Введите число вершин графа: "))
matrix = []
print("Введите матрицу весов (элементы через пробел, 'inf' - отсутствие ребра):")
for i in range(n):
    row = []
    elements = input(f"Строка {i + 1}: ").split()
    for element in elements:
        if element == 'inf':
            row.append(math.inf)
        else:
            row.append(int(element))
    matrix.append(row)

vertices = list(range(1, n + 1))
edges = []
total_cost = 0

current_rows = vertices.copy()
current_cols = vertices.copy()

reduced_matrix = [row.copy() for row in matrix]

for k in range(n - 1):
    row_mins = [math.inf] * len(reduced_matrix)
    for i in range(len(reduced_matrix)):
        min_val = min(reduced_matrix[i])
        if min_val != math.inf:
            row_mins[i] = min_val
    for i in range(len(reduced_matrix)):
        if row_mins[i] != math.inf:
            total_cost += row_mins[i]
            for j in range(len(reduced_matrix)):
                if reduced_matrix[i][j] != math.inf:
                    reduced_matrix[i][j] -= row_mins[i]

    col_mins = [math.inf] * len(reduced_matrix)
    for j in range(len(reduced_matrix)):
        min_val = math.inf
        for i in range(len(reduced_matrix)):
            if reduced_matrix[i][j] < min_val:
                min_val = reduced_matrix[i][j]
        if min_val != math.inf:
            col_mins[j] = min_val
    for j in range(len(reduced_matrix)):
        if col_mins[j] != math.inf:
            total_cost += col_mins[j]
            for i in range(len(reduced_matrix)):
                if reduced_matrix[i][j] != math.inf:
                    reduced_matrix[i][j] -= col_mins[j]

    max_penalty = -1
    best_edge = None
    for i in range(len(reduced_matrix)):
        for j in range(len(reduced_matrix)):
            if reduced_matrix[i][j] == 0:
                min_row = math.inf
                for col in range(len(reduced_matrix)):
                    if col != j and reduced_matrix[i][col] < min_row:
                        min_row = reduced_matrix[i][col]
                min_col = math.inf
                for row in range(len(reduced_matrix)):
                    if row != i and reduced_matrix[row][j] < min_col:
                        min_col = reduced_matrix[row][j]
                penalty = min_row + min_col
                if penalty > max_penalty:
                    max_penalty = penalty
                    best_edge = (i, j)

    i, j = best_edge
    edges.append((current_rows[i], current_cols[j]))
    
    del_row = current_rows[i]
    del_col = current_cols[j]
    
    current_rows.remove(del_row)
    current_cols.remove(del_col)
    
    new_size = len(reduced_matrix) - 1
    new_matrix = []
    for row_idx in range(len(reduced_matrix)):
        if row_idx == i:
            continue
        new_row = []
        for col_idx in range(len(reduced_matrix)):
            if col_idx == j:
                continue
            new_row.append(reduced_matrix[row_idx][col_idx])
        new_matrix.append(new_row)
    
    if del_col in current_rows and del_row in current_cols:
        row_idx = current_rows.index(del_col)
        col_idx = current_cols.index(del_row)
        new_matrix[row_idx][col_idx] = math.inf
    
    reduced_matrix = new_matrix

if len(current_rows) == 1 and len(current_cols) == 1:
    edges.append((current_rows[0], current_cols[0]))

print("\nОптимальный путь:", edges)
print("Минимальная стоимость:", total_cost)