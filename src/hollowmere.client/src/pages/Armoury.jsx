import { useState } from 'react';


const items = [
    {id: 1, name: 'Sword', kind: 'Weapon', condition: 'New', isDangerous: true, isRetired: false},
    {id: 2, name: 'Sword', kind: 'Weapon', condition: 'New', isDangerous: true, isRetired: false},
    {id: 3, name: 'Sword', kind: 'Weapon', condition: 'Used', isDangerous: true, isRetired: false},
    {id: 4, name: 'Sword', kind: 'Weapon', condition: 'Damaged', isDangerous: true, isRetired: true},
    {id: 5, name: 'Sword', kind: 'Weapon', condition: 'Used', isDangerous: true, isRetired: false},
    {id: 6, name: 'Sword', kind: 'Weapon', condition: 'Used', isDangerous: true, isRetired: false},
];

function Armoury() {
    return (
        <div>
            <h1>Armoury</h1>
            <table>
                <thead>
                    <tr>
                        <th>Name</th>
                        <th>Kind</th> 
                        <th>Condition</th>
                        <th>Dangerous</th>
                        <th>Retired</th>
                    </tr>
                </thead>
                <tbody>
                    {items.map(item => 
                        <tr key={item.id}>
                            <td>{item.name}</td>
                            <td>{item.kind}</td>
                            <td>{item.condition}</td>
                            <td>{item.isDangerous ? 'Yes' : 'No'}</td>
                            <td>{item.isRetired ? 'Yes' : 'No'}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        </div>
    );
}

export default Armoury;


const currentUser = { id: 1, name: 'John Doe', role: 'User', isTrained: false };

function Armoury() {
    const [loans, setLoans] = useState([
        { id: 1, itemId: 3, userId: 'u2', loanDate: '2026-10-01', returnDate: null, returnCondition: null },
    ]);
    const [onlyAvailable, setOnlyAvailable] = useState(false);


    function isOnLoan(itemId) {
        return loans.some(l => l.itemId === itemId && l.returnDate === null);
    }

    function canBorrow(item) {
        if (item.isRetired) return false;
        if (isOnLoan(item.id)) return false;
        if (item.isDangerous && !currentUser.isTrained) return false;
        return true;
    }

    function borrow(item) {
        const newLoan = {
            id: loans.length + 1,
            itemId: item.id,
            userId: currentUser.id,
            loanDate: new Date().toISOString().slice(0, 10),
            returnDate: null,
            returnCondition: null,
        };
        setLoans([...loans, newLoan]);
    }

    const visibleItems = items
        .filter(i => !i.isRetired)
        .filter(i => !onlyAvailable || !isOnLoan(i.id));

    return (
        <div>
            <h1>Armoury</h1>
            <label>
                <input type="checkbox" checked={onlyAvailable}
                       onChange={e => setOnlyAvailable(e.target.checked)} />
                Only available
            </label>


            <table>
                <thead>
                    <tr>
                        <th>Name</th>
                        <th>Kind</th>
                        <th>Condition</th>
                        <th>Dangerous</th>
                        <th>Status</th>
                        <th>Action</th>
                    </tr>
                </thead>
                <tbody>
                    {visibleItems.map(item =>
                        <tr key={item.id}>
                            <td>{item.name}</td>
                            <td>{item.kind}</td>
                            <td>{item.condition}</td>
                            <td>{item.isDangerous ? 'Yes' : 'No'}</td>
                            <td>{isOnLoan(item.id) ? 'On loan' : 'Available'}</td>
                            <td>
                                <button disabled={!canBorrow(item)} onClick={() => borrow(item)}>
                                    Borrow
                                </button>
                            </td>
                        </tr>
                    )}
                </tbody>
            </table>
        </div>
    );
}