with open('Input.txt', 'r') as Inp:
    G = [list(map(float, line.split())) for line in Inp.read().split('\n')]
    n = len(G)
    V = set(list(range(n)))
    U = {V.pop()}  

mst = []
while V:
    E = []
    for u in U:
        for v in V:
            E.append((G[v][u], v, u))
    e, v, u = min(E)
    mst.append((e, v, u))
    U.add(v)
    V.remove(v)

print(sum([e for e, v, u in mst]))