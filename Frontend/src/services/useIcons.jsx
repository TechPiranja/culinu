import * as MuiIcons from "@mui/icons-material";

function useIcons(name) {
	const Icon = MuiIcons[name];
	return Icon;
}

export default useIcons;
