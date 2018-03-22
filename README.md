# Artificial_IntelligenceProject
<u>AI project folder containe many search algorithm as:</u><br>
DFS<br>
BFS<br>
BEST FIRST SEARCH<br>
ASTAR<br>
<br>
Develope as generic classes that can resolve any problem that implement interface 'ISearchable'<br>
ISearchable interface provide the methods:<br>
getInitialState() : State<><br>
isGoalState(State<>) : Bool<br>
getSeccesors(State<>) : List<State<>><br>
<br>
State class is a unit in search algorithm that contain information about some situation/grid of the agent<br>
<br>
<u>Maze Project folder contain classes that present map of maze problem</u><br>
In the Main method there is a map generator that create random map<br>
Maze class implements the 'ISearchable' interface.<br>
More than thatm there is Windows Form Class that make visual map for user that present the optimal solution
