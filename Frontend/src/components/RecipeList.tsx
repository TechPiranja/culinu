import ListItem from "@mui/material/ListItem";
import ListItemButton from "@mui/material/ListItemButton";
import ListItemText from "@mui/material/ListItemText";
import { FixedSizeList, ListChildComponentProps } from "react-window";
// @ts-ignore
import AutoSizer from "react-virtualized-auto-sizer";
import { Card, CardContent } from "@mui/material";

function renderRow(props: ListChildComponentProps) {
	const { index, style } = props;

	return (
		<ListItem style={style} key={index} component="div" disablePadding>
			<ListItemButton>
				<ListItemText primary={`Recipe ${index + 1}`} />
			</ListItemButton>
		</ListItem>
	);
}

export default function RecipeList() {
	return (
		<Card sx={{ minWidth: 275, width: "30%" }}>
			<CardContent sx={{ height: "100%", p: 0 }}>
				<AutoSizer>
					{({ height, width }: any) => (
						<FixedSizeList height={height} width={width} itemSize={46} itemCount={200} overscanCount={5}>
							{renderRow}
						</FixedSizeList>
					)}
				</AutoSizer>
			</CardContent>
		</Card>
	);
}
