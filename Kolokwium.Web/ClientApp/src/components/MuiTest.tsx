import React from "react";
import Card from '@mui/material/Card';
import CardActions from '@mui/material/CardActions';
import CardContent from '@mui/material/CardContent';
import { CardHeader } from '@mui/material';
import Button from '@mui/material/Button';

export const MuiTest = () => {
    return (
        <Card>
            <CardHeader title={"MUI test"} >
            </CardHeader>
            <CardContent>
                <p>
                   Do you like MUI
                </p>
                <hr />
            </CardContent>
            <CardActions>
                <Button variant="contained" >YES</Button>
                <Button variant="contained" >NO</Button>
            </CardActions>
        </Card>
    );
}