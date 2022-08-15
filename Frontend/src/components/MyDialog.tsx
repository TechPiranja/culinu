import * as React from "react";
import Button from "@mui/material/Button";
import Dialog from "@mui/material/Dialog";
import DialogActions from "@mui/material/DialogActions";
import DialogContent from "@mui/material/DialogContent";
import DialogTitle from "@mui/material/DialogTitle";
import { useEffect } from "react";
import { Fab, IconButton } from "@mui/material";
import useIcons from "../services/useIcons";
import { Add } from "@mui/icons-material";

export default function MyDialog(props: any) {
	const [open, setOpen] = React.useState(false);

	useEffect(() => {
		setOpen(props.open ?? false);
	}, [props.open]);

	const handleClickOpen = (e: any) => {
		e.stopPropagation();
		setOpen(true);
	};

	const handleClose = (event: any, reason: any) => {
		if (props.noBackdrop && reason && reason == "backdropClick") return;
		if (props.setOpen) props.setOpen(false);
		setOpen(false);
	};

	const descriptionElementRef = React.useRef<HTMLElement>(null);
	React.useEffect(() => {
		if (open) {
			const { current: descriptionElement } = descriptionElementRef;
			if (descriptionElement !== null) {
				descriptionElement.focus();
			}
		}
	}, [open]);

	const MyIcon = (data: any) => {
		const CustomIcon = useIcons(data.iconName);
		return <CustomIcon />;
	};

	return (
		<div>
			{props.showButton &&
				(props.isEdit || props.isDelete ? (
					<IconButton onClick={handleClickOpen} color="primary">
						<MyIcon iconName={props.iconName ?? "Edit"} />
					</IconButton>
				) : props.ownButton ? (
					<Fab onClick={handleClickOpen} color="secondary" aria-label="add" style={{ position: "absolute", bottom: 40, right: 30 }}>
						<Add />
					</Fab>
				) : (
					<Button size="small" onClick={handleClickOpen} startIcon={<MyIcon iconName={props.iconName ?? "Add"} />}>
						{props.btnOpen ?? "create"}
					</Button>
				))}
			<Dialog open={open} onClose={handleClose} maxWidth={"lg"}>
				{props.title && <DialogTitle>{props.title}</DialogTitle>}
				<DialogContent dividers>{props.children}</DialogContent>
				{props.withActions && (
					<DialogActions>
						<Button
							variant="contained"
							onClick={async () => {
								let success = await props.saveItem();
								if (success) {
									if (props.setOpen) props.setOpen(false);
									setOpen(false);
								}
							}}
						>
							{props.handleBtnTitle ?? (props.isEdit ? "save" : "create")}
						</Button>
						<Button
							onClick={() => {
								if (props.setOpen) props.setOpen(false);
								setOpen(false);
							}}
						>
							cancel
						</Button>
					</DialogActions>
				)}
			</Dialog>
		</div>
	);
}
