import "./App.css";
import TitleBar from "./components/TitleBar";
import { Box, Toolbar } from "@mui/material";
import RecipeList from "./components/RecipeList";
import RecipeDetail from "./components/RecipeDetail";

function App() {
	return (
		<Box sx={{ display: "flex", height: "100%", flexDirection: "column", background: "#e5e9f1" }}>
			<TitleBar />
			<Toolbar />
			<Box component="main" sx={{ p: 3, flex: 1, height: "100%", display: "flex", flexDirection: "row", gap: 3 }}>
				<RecipeList />
				<RecipeDetail />
			</Box>
		</Box>
	);
}

export default App;
