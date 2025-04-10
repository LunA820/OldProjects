# LeetTrader (Server)

link: https://leettrader-lpzks.ondigitalocean.app/

LeetTrader is a stock trading simulator that could help novice investor to practice investment. This project is the server-side implementation of LeetTrader, built on NodeJS and Express. It fetches API of https://finnhub.io/ to get latest stock information.

For demonstration purpose, it uses both SQL (MySQL) and NoSQL (MongoDB) to handle data. Users and transaction records are handled by MySQL, and Watchlist is handled by MongoDB.

It is recommended to just register your own account. However, you can also explore the application without registration by using the guest account, which shares data publicly.
