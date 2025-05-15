import { useState } from "react";
import api from "../api";

export default function FormAddAchievement() {
    const userRole = localStorage.getItem("userRole");

    const [title, setTitle] = useState("");
    const [description, setDescription] = useState("");
    const [event, setEvent] = useState("");
    const [message, setMessage] = useState("");

    if (userRole !== "admin" && userRole !== "teacher") {
        return <p>Нямате права да добавяте постижения.</p>;
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

            setMessage("Постижението е добавено успешно!");
            setTitle("");
            setDescription("");
            setEvent("");
        } catch (err) {
            setMessage("Грешка при добавяне.");
        }
    };

    return (
        <form onSubmit={handleSubmit}>
            <h2>Добави постижение</h2>
            <input
                type="text"
                placeholder="Заглавие"
                value={title}
                onChange={(e) => setTitle(e.target.value)}
                required
            />
            <input
                type="text"
                placeholder="Събитие (например: олимпиада, състезание)"
                value={event}
                onChange={(e) => setEvent(e.target.value)}
                required
            />
            <textarea
                placeholder="Описание"
                value={description}
                onChange={(e) => setDescription(e.target.value)}
                required
            />
            <button type="submit">Добави</button>
            {message && <p>{message}</p>}
        </form>
    );
}
