import { Box, Button, Card, CardActions, CardContent, CardHeader, TextField } from "@mui/material";
import axios from "axios";
import React, { useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import { ICar } from "../../models/ICar";
import CancelIcon from '@mui/icons-material/Cancel';
import SaveIcon from '@mui/icons-material/Save';

interface IProps {
    labelName: string;
}

export const CarAddOrEditForm = (props: IProps) => {
    const navigate = useNavigate();
    const params = useParams();

    const [state, setState] = useState<ICar>({
        id: 0,
        brand: "",
        model: "",
        yearOfProduction: 0
    });

    useEffect(() => {
        const id: number | undefined = params["id"] ? parseInt(params["id"]) : undefined;
        if (id !== undefined) {
            const getCar = async () => {
                const response = await axios.get<ICar>(`/api/Car/${id}`);
                if (response.status === 200) {
                    setState({ ...response.data });
                }
            }
            getCar();
        }
    }, []);

    const onInputTextChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        const name = e.target.name as keyof typeof state;
        setState(state => ({ ...state, [name]: e.target.value }));
    }

    const onSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
        e.preventDefault();
        const response = await axios.post<ICar>("/api/Car", state);
        if (response.status === 200) {
            setState({
                id: 0,
                brand: "",
                model: "",
                yearOfProduction: 0
            });
            navigate("/car");
        }
    }

    const onCancel = (e: React.MouseEvent<HTMLButtonElement>) => {
        e.preventDefault();
        navigate("/car");
    };

    return (
        <div className="form-container">
            <Box
                component="form"
                sx={{
                    '.MuiTextField-root': { m: 1, width: '25ch' },
                }}
                noValidate
                autoComplete="off"
                onSubmit={onSubmit}
            >
                <Card>
                    <CardHeader title={props.labelName}>
                    </CardHeader>
                    <CardContent>
                        <div>
                            <input type="hidden" value={state.id} />
                            <TextField
                                required
                                onChange={onInputTextChange}
                                label="Brand"
                                name="brand"
                                value={state.brand}
                            />
                            <TextField
                                required
                                onChange={onInputTextChange}
                                label="Model"
                                name="model"
                                value={state.model}
                            />
                            <TextField
                                required
                                onChange={onInputTextChange}
                                label="YearOfProduction"
                                name="yearOfProduction"
                                value={state.yearOfProduction}
                            />
                        </div>
                        <hr />
                    </CardContent>
                    <CardActions>
                        <Button type="submit" variant="contained" endIcon={<SaveIcon/>}>Save</Button>
                        <Button type="button" variant="contained" onClick={onCancel} endIcon={<CancelIcon />}>Cancel</Button>
                    </CardActions>
                </Card>
            </Box>
        </div>
    );
};
