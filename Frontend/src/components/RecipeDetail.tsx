import { Card, CardContent, Typography } from "@mui/material";
import React from "react";
import { useSelector } from "react-redux";
import { RootState } from "../redux/store";

export default function RecipeDetail() {
	const selectedRecipe = useSelector((state: RootState) => state.recipes.selectedRecipe);

	return (
		<Card sx={{ minWidth: 275, width: "70%" }}>
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
					{selectedRecipe.name}
				</Typography>
				{!selectedRecipe.name?.length ? (
					<Typography style={{ margin: 10, textAlign: "center", color: "grey" }}>No recipe selected</Typography>
				) : (
					<div style={{ margin: 10 }}>
						<Typography style={{ fontWeight: "bold" }}>Ingredients:</Typography>
						{selectedRecipe.ingredients.map((item: any) => (
							<Typography>{item.name}</Typography>
						))}
						{/* <Typography>Description:</Typography> */}
					</div>
				)}
			</CardContent>
		</Card>
	);
}
