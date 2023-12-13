import { Button, Card, CardActions, CardContent, CardHeader } from "@mui/material";
import axios from "axios";
import React from "react";
import { useNavigate, useParams } from "react-router";

export const CarDelete = () => {
    const navigate = useNavigate();
    const params = useParams();

    const onDeleteHandler = async (e: React.MouseEvent<HTMLButtonElement>) => {
        e.preventDefault();
        const id: number | undefined = params["id"] ? parseInt(params["id"]): undefined;
        if (id !== undefined) {
            const deleteCar = async () => {
                const response = await axios.delete(`/api/Car/${id}`);
                navigate("/car");
            }
            deleteCar();
        }
    }

    const onCancleHandler = (e: React.MouseEvent<HTMLButtonElement>) => {
        e.preventDefault();
        navigate("/car");
    }

    return (
        <Card>
            <CardHeader title={"Delete Car"}>
            </CardHeader>
            <CardContent>
                <p>
                    Delete?
                </p>
                <hr />
            </CardContent>
            <CardActions>
                <Button variant="contained" onClick={onDeleteHandler}> Delete</Button>
                <Button variant="contained" onClick={onCancleHandler}> Cancel</Button>
            </CardActions>
        </Card>
    )
}