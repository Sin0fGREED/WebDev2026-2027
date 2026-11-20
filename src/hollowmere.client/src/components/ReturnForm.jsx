import { useState,} from 'react';

function ReturnForm({ loan, onReturn }) {
    const [note, setnote] = useState('');

    function handleSubmit(e) {
        e.preventDefault();
        if (note.trim() === '') {
            alert('Please enter a note before returning the item.');
            return;
        }
        onReturn(loan.id, note);    
        setnote('');
    }

    return (
        <form onSubmit={handleSubmit}>
            <input
                value={note}
                onChange={(e) => setnote(e.target.value)}
                placeholder="Condition, e.g. 'Good', 'Damaged', etc."
            />
            <button type="submit" disabled={note.trim() === ''}>Return</button>
        </form>
    );
} 

export default ReturnForm;