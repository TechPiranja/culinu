import ListItem from "@mui/material/ListItem";
import ListItemButton from "@mui/material/ListItemButton";
import ListItemText from "@mui/material/ListItemText";
// @ts-ignore
import AutoSizer from "react-virtualized-auto-sizer";
import { Card, Typography, CardContent, Divider, List } from "@mui/material";
import { Add } from "@mui/icons-material";
import { useDispatch, useSelector } from "react-redux";
import { RootState } from "../redux/store";
import { updateRecipes, updateSelectedRecipe } from "../redux/slices/recipeSlice";
import { defaultService } from "../services/api";
import { useEffect } from "react";
import CreateRecipe from "./CreateRecipe";

export default function RecipeList() {
	const recipes = useSelector((state: RootState) => state.recipes.recipes);
	const dispatch = useDispatch();

	useEffect(() => {
		defaultService.getPrimitive("Recipe").then((result: any) => dispatch(updateRecipes(result.data)));
	}, []);

	return (
		<Card sx={{ minWidth: 275, width: "30%" }}>
			<CardContent sx={{ height: "100%", p: 0 }}>
				<Typography
					style={{
						width: "100%",
						background: "#6f6ffb",
						textAlign: "center",
						fontSize: 22,
						padding: 10,
						color: "white",
						fontWeight: "bold",
					}}
				>
					Recipes
				</Typography>
				<AutoSizer>
					{({ height, width }: any) => (
						<List style={{ height: height, width: width }}>
							{recipes?.map((recipe, index): any => (
								<div key={index}>
									<ListItem component="div" disablePadding>
										<ListItemButton onClick={() => dispatch(updateSelectedRecipe(recipe))}>
											<ListItemText primary={recipe.name} />
										</ListItemButton>
									</ListItem>
									<Divider />
								</div>
							))}
						</List>
						// <FixedSizeList height={height} width={width} itemSize={46} itemCount={200} overscanCount={5}>
						// 	{renderRow}
						// </FixedSizeList>
					)}
				</AutoSizer>
				<CreateRecipe />
				{/* <Fab color="secondary" aria-label="add" style={{ position: "absolute", bottom: 40, right: 30 }}>
					<Add />
				</Fab> */}
			</CardContent>
		</Card>
	);
}
