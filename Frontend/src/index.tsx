import React from "react";
import ReactDOM from "react-dom/client";
import "./index.css";
import App from "./App";
import reportWebVitals from "./reportWebVitals";
import { createTheme, ThemeProvider } from "@mui/material/styles";
import { Provider } from "react-redux";
import { store } from "./redux/store";
import { SnackbarProvider } from "notistack";

const root = ReactDOM.createRoot(document.getElementById("root") as HTMLElement);

const theme = createTheme({
	palette: {
		primary: {
			main: "#6f6ffb",
			dark: "#0eec94",
		},
		secondary: {
			main: "#0eec94",
		},
		background: {
			default: "#fcfcfc",
		},
	},
});

root.render(
	<React.StrictMode>
		<Provider store={store}>
			<SnackbarProvider maxSnack={3}>
				<ThemeProvider theme={theme}>
					<App />
				</ThemeProvider>
			</SnackbarProvider>
		</Provider>
	</React.StrictMode>
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
