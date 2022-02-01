Run the app locally

npm start

Build Docker image

docker image build -t wishlist:client .

Run container

docker run -d -p 3001:3001 wishlist:client