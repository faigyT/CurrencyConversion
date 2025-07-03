import { useState, useEffect } from 'react';
import {
	TextField,
	Button,
	MenuItem,
	Grid,
	Typography,
	Paper,
	CircularProgress,
	IconButton
} from '@mui/material';
import axios from 'axios';
import SwapHorizIcon from '@mui/icons-material/SwapHoriz';
import { getAllCurrencies, getRequestedAmount } from './ConversionApi';
const ConversionPlatform = () => {

	const [amount, setAmount] = useState('');
	const [fromCurrency, setFromCurrency] = useState('');
	const [toCurrency, setToCurrency] = useState('');
	const [currencies, setCurrencies] = useState([]);
	const [convertedAmount, setConvertedAmount] = useState(null);
	const [loading, setLoading] = useState(false);

	useEffect(() => {
		getAllCurrencies()
			.then(res => setCurrencies(res.data))
			.catch(err => console.error('Error loading currencies:', err));
	}, []);

	const handleSwap = () => {
		// החלפה בין מטבעות
		setFromCurrency(toCurrency);
		setToCurrency(fromCurrency);

		setConvertedAmount('');
	};

	const handleConvert = () => {
		if (!amount || !fromCurrency || !toCurrency) return;

		setLoading(true);
		getRequestedAmount({ SourceCurrency: fromCurrency, TargetCurrency: toCurrency, Amount: amount })
			.then(res => {
				setConvertedAmount(res.data);
				console.log(res.data);

				setLoading(false);
			})
			.catch(err => {
				console.error('Conversion error:', err);
				setLoading(false);
			});
	};

	return (

		<Paper elevation={3} style={{ direction: "rtl", textAlign: "center", padding: '2rem', maxWidth: 500, margin: '2rem auto' }}>
			<Typography variant="h5" gutterBottom>המרת מטבע</Typography>
			<Grid container spacing={2} alignItems="center">
				{/* שורה ראשונה: סכום + מטבע מקור */}
				<Grid container item spacing={2} alignItems="center">
					<Grid item xs={6}>
						<TextField
							select
							label="מטבע מקור"
							fullWidth

							value={fromCurrency}
							sx={{
								mr: 2,
								ml:8
							}}
							onChange={e => setFromCurrency(e.target.value)}
						>
							{currencies.map(curr => (
								<MenuItem key={curr} value={curr}>{curr}</MenuItem>
							))}
						</TextField>
					</Grid>

					<Grid item xs={2} style={{ textAlign: 'center' }}>
						<IconButton
							color="primary"
							onClick={handleSwap}
							aria-label="Swap currencies"
							size="large"
							sx={{
								mr: 4
							}}
						>
							<SwapHorizIcon fontSize="large" />
						</IconButton>
					</Grid>

					<Grid item xs={6}>
						<TextField
							select
							label="מטבע יעד"
							sx={{
								mr: 6
							}}
							fullWidth
							value={toCurrency}
							onChange={e => setToCurrency(e.target.value)}
						>
							{currencies.map(curr => (
								<MenuItem key={curr} value={curr}>{curr}</MenuItem>
							))}
						</TextField>
					</Grid>
				</Grid>

				{/* שורה שנייה: תוצאה readonly + מטבע יעד */}
				<Grid container item spacing={2}>
					<Grid item xs={6}>
						<TextField
							label="סכום"
							type="number"
							sx={{ width: "100%" }}
							value={amount}
							onChange={e => setAmount(e.target.value)}
						/>
					</Grid>

					<Grid item xs={6}>
						<TextField
							label="סכום"
							value={convertedAmount ? Number(convertedAmount).toFixed(2) : ''}
							fullWidth
							InputProps={{ readOnly: true }}
							placeholder="הסכום המומר"
						/>
					</Grid>
				</Grid>


				{/* כפתור המרה */}
				<Grid item xs={12}>
					<Button
						variant="contained"
						color="primary"
						onClick={handleConvert}
						fullWidth
						sx={{ mr: 17 }}
						disabled={loading}
					>
						{loading ? <CircularProgress size={24} color="inherit" /> : 'המר'}
					</Button>
				</Grid>
			</Grid>
		</Paper>
	);
}

export default ConversionPlatform;