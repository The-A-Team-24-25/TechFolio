import React from "react";
import { useForm } from "../useForm";
import { registerFromInvitation } from "../services/api.js";

export const RegisterFromInvitation = () => {
    const { formData, handleChange, handleSubmit } = useForm(onSubmit, {
        firstName: "",
        lastName: "",
        email: "",
        password: "",
        confirmPassword: ""
    });

    async function onSubmit() {
        const token = localStorage.getItem("token");
        const invitationId = localStorage.getItem("invitationId");

        if (!token || !invitationId) {
            alert("?????? ?????? ??? ?????.");
            return;
        }

        if (formData.password !== formData.confirmPassword) {
            alert("???????? ?? ????????.");
            return;
        }

        await registerFromInvitation({ ...formData, invitationId }, token);
    }

    return (
        <form onSubmit={handleSubmit}>
            <h2>??????????? ?? ??????</h2>
            <input name="firstName" placeholder="???" onChange={handleChange} value={formData.firstName} required />
            <input name="lastName" placeholder="???????" onChange={handleChange} value={formData.lastName} required />
            <input name="email" type="email" placeholder="?????" onChange={handleChange} value={formData.email} required />
            <input name="password" type="password" placeholder="??????" onChange={handleChange} value={formData.password} required />
            <input name="confirmPassword" type="password" placeholder="???????? ??????" onChange={handleChange} value={formData.confirmPassword} required />
            <button type="submit">??????????? ??</button>
        </form>
    );
};
