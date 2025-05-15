import React, { useEffect } from "react";
import { useForm } from "../useForm";
import { submitStudentProfile } from "../services/api";

export const StudentProfile = () => {
    const { formData, handleChange, handleSubmit } = useForm(onSubmit, {
        portfolio: "",
        mentor: "",
        goals: "",
        interests: ""
    });

    useEffect(() => {
        const token = localStorage.getItem("token");
        const invitationId = localStorage.getItem("invitationId");

        if (!token || !invitationId) {
            alert("?????? ?????? ??? ?????.");
        }
    }, []);

    async function onSubmit() {
        const token = localStorage.getItem("token");
        const invitationId = localStorage.getItem("invitationId");

        await submitStudentProfile({ ...formData, invitationId }, token);
    }

    return (
        <form onSubmit={handleSubmit}>
            <h2>?????????</h2>
            <textarea name="portfolio" placeholder="????? ???? ? ???????" onChange={handleChange} value={formData.portfolio} required />

            <h3>??????</h3>
            <input name="mentor" placeholder="??? ?? ??????" onChange={handleChange} value={formData.mentor} required />

            <h3>????</h3>
            <textarea name="goals" placeholder="????? ?????? ???? ?? ????????" onChange={handleChange} value={formData.goals} required />

            <h3>????????</h3>
            <textarea name="interests" placeholder="???????? ? ??????" onChange={handleChange} value={formData.interests} required />

            <button type="submit">?????? ???????</button>
        </form>
    );
};

