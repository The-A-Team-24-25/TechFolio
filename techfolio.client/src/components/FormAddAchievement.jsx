import { useState } from "react";
import api from "../api";

export default function FormAddAchievement() {
    const userRole = localStorage.getItem("userRole");

    const [title, setTitle] = useState("");
    const [description, setDescription] = useState("");
    const [event, setEvent] = useState("");
    const [message, setMessage] = useState("");

    if (userRole !== "admin" && userRole !== "teacher") {
        return <p>������ ����� �� �������� ����������.</p>;
    }

    const handleSubmit = async (e) => {
        e.preventDefault();
        setMessage("");

        try {
            const response = await api.post("/achievements", {
                title,
                description,
                event,
            });

            setMessage("������������ � �������� �������!");
            setTitle("");
            setDescription("");
            setEvent("");
        } catch (err) {
            setMessage("������ ��� ��������.");
        }
    };

    return (
        <form onSubmit={handleSubmit}>
            <h2>������ ����������</h2>
            <input
                type="text"
                placeholder="��������"
                value={title}
                onChange={(e) => setTitle(e.target.value)}
                required
            />
            <input
                type="text"
                placeholder="������� (��������: ���������, ����������)"
                value={event}
                onChange={(e) => setEvent(e.target.value)}
                required
            />
            <textarea
                placeholder="��������"
                value={description}
                onChange={(e) => setDescription(e.target.value)}
                required
            />
            <button type="submit">������</button>
            {message && <p>{message}</p>}
        </form>
    );
}
