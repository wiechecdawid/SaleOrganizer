import { FC } from "react";
import styled from "styled-components";

const Form = styled.form``

interface Props {
    onSubmit: any
}

export const CustomForm: FC<Props> = ({ onSubmit, children }) => (
    <Form onSubmit={onSubmit}>
        { children }
    </Form>
)