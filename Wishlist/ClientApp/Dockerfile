FROM node:lts-alpine
ENV NODE_ENV=production
WORKDIR /usr/src/app
COPY package.json ./
COPY package-lock.json* ./
RUN npm install 
COPY . .
EXPOSE 3001
RUN chown -R node /usr/src/app
USER node
CMD ["yarn", "start"]
