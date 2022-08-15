import "./App.css";
import TitleBar from "./components/TitleBar";
import { Box, Toolbar } from "@mui/material";

function App() {
	return (
		<Box sx={{ display: "flex" }}>
			<TitleBar />
			<Box component="main" sx={{ p: 3 }}>
				<Toolbar />
				<p>In Progress</p>
			</Box>
		</Box>
	);
}

export default App;
