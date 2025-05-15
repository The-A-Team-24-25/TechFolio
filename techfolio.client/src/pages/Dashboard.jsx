import { useAuth } from "../context/AuthProvider";
import { useEffect } from "react";
import { useNavigate } from "react-router-dom";

export const Dashboard = () => {
    const { user } = useAuth();
    const navigate = useNavigate();

    useEffect(() => {
        if (!user) return;
        switch (user.role) {
            case "Student":
                navigate("/student/profile");
                break;
            case "Teacher":
                navigate("/student/overview");
                break;
            default:
                navigate("/login");
        }
    }, [user, navigate]);

    return null;
};
