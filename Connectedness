with open('Input.txt', 'r') as Inp:
    G = [list(map(int, line.split())) for line in Inp.read().split('\n')]
    n = len(G)
    visit = set()

edges = []
for u in range(n):
    for v in range(n):
        if G[v][u] != 0 and {v, u} not in edges:
            edges.append({v, u})

components = []
for edge_1 in edges:
    if not edge_1 & visit:
        for edge_2 in edges:
            if edge_1 & edge_2:
                edge_1 |= edge_2
                visit |= edge_1
        components.append(edge_1)

[print(component) for component in components]
