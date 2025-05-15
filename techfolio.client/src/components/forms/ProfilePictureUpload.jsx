import React, { useState, useRef } from 'react';

const ProfilePictureUpload = ({ studentId }) => {
    const [previewUrl, setPreviewUrl] = useState(null);
    const [error, setError] = useState('');
    const fileInputRef = useRef();

    const handleFileSelect = () => {
        fileInputRef.current.click();
    };

    const handleFileChange = async (e) => {
        const file = e.target.files[0];
        if (!file) return;

        const validTypes = ['image/jpeg', 'image/png', 'image/gif'];
        if (!validTypes.includes(file.type)) {
            setError('��������� �������: JPG, PNG, GIF');
            return;
        }

        if (file.size > 2 * 1024 * 1024) {
            setError('������ ������ �� � ��� 2MB');
            return;
        }

        setError('');
        const formData = new FormData();
        formData.append('profilePicture', file);

        try {
            await fetch(`/students/${studentId}/profile-picture`, {
                method: 'POST',
                body: formData,
            });

            const imageUrl = URL.createObjectURL(file);
            setPreviewUrl(imageUrl);
        } catch {
            setError('������ ��� ������� �� �����');
        }
    };

    return (
        <form onSubmit={(e) => e.preventDefault()}>
            <label htmlFor="fileUpload">���� ������:</label><br />
            <button type="button" onClick={handleFileSelect}>������ ����</button>
            <input
                type="file"
                id="fileUpload"
                accept="image/*"
                onChange={handleFileChange}
                ref={fileInputRef}
                style={{ display: 'none' }}
            />
            {error && <p style={{ color: 'red' }}>{error}</p>}
            {previewUrl && (
                <div>
                    <p>�������:</p>
                    <img src={previewUrl} alt="�������� ������" width={150} />
                </div>
            )}
        </form>
    );
};

export default ProfilePictureUpload;