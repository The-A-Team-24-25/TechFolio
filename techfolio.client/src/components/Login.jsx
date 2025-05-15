import { useState } from "react";
import api from "../api";

export default function Login({ onLogin }) {
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const [error, setError] = useState("");

    const handleSubmit = async (e) => {
        e.preventDefault();
        setError("");

        try {
            const response = await api.post("/auth/login", {
                email,
                password,
            });

            const { accessToken, user } = response.data;
            localStorage.setItem("accessToken", accessToken);
            localStorage.setItem("userRole", user.role); // admin, student i tn

            if (onLogin) onLogin(user);
        } catch (err) {
            setError("Грешен имейл или парола");
        }
    };

    return (
        <form onSubmit={handleSubmit}>
            <h2>Вход</h2>
            <input
                type="email"
                placeholder="Имейл"
                value={email}
                onChange={(e) => setEmail(e.target.value)}
                required
            />
            <input
                type="password"
                placeholder="Парола"
                value={password}
                onChange={(e) => setPassword(e.target.value)}
                required
            />
            <button type="submit">Вход</button>
            {error && <p style={{ color: "red" }}>{error}</p>}
        </form>
    );
}
