import React from 'react';
import { useEffect, useState } from 'react';
import { BrowserRouter, Routes, Route, Navigate } from "react-router-dom";
import { AuthProvider, useAuth } from "./context/AuthProvider";
import Login from "./pages/Login";
import Dashboard from "./pages/Dashboard";
import StudentProfile from "./pages/StudentProfile";
import StudentOverviewPage from "./pages/StudentOverviewPage";
import RegisterFromInvitation from "./components/RegisterFromInvitation";
import FormAddAchievement from "./components/FormAddAchievement";
import './App.css';
import FormAddInterest from './components/FormAddInterest';

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
