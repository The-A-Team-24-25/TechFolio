import { useEffect, useState } from 'react';
import { BrowserRouter, Routes, Route, Navigate } from "react-router-dom";
<<<<<<< HEAD
import { AuthProvider, useAuth } from "./context/AuthProvider.jsx";
import Login from "./pages/Login.jsx";
import Dashboard from "./pages/Dashboard.jsx";
import StudentProfile from "./pages/StudentProfile.jsx";
import StudentOverviewPage from "./pages/StudentOverviewPage.jsx";
import RegisterFromInvitation from "./components/RegisterFromInvitation.jsx";
import './App.css';


const RequireAuth = ({ children }) => {
    const { token } = useAuth();
    return token ? children : <Navigate to="/login" />;
};

const RequireRole = ({ allowedRoles, children }) => {
    const { user } = useAuth();
    return user && allowedRoles.includes(user.role)
        ? children
        : <Navigate to="/login" />;
};

export const App = () => (
    <AuthProvider>
        <BrowserRouter>
            <Routes>
                <Route path="/login" element={<Login />} />
                <Route path="/register/:invitationId" element={<RegisterFromInvitation />} />

                <Route path="/dashboard" element={
                    <RequireAuth>
                        <Dashboard />
                    </RequireAuth>
                } />

                <Route path="/student/profile" element={
                    <RequireAuth>
                        <RequireRole allowedRoles={["Student"]}>
                            <StudentProfile />
                        </RequireRole>
                    </RequireAuth>
                } />

                <Route path="/student/overview" element={
                    <RequireAuth>
                        <RequireRole allowedRoles={["Teacher"]}>
                            <StudentOverviewPage />
                        </RequireRole>
                    </RequireAuth>
                } />

                <Route path="*" element={<Navigate to="/login" />} />
            </Routes>
        </BrowserRouter>
    </AuthProvider>
);
